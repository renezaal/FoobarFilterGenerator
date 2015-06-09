using System;
using System.Text;
using System.Windows.Forms;

namespace FoobarFilterGenerator
{
    public partial class FilterGenerator : Form
    {
        #region class wide variables
        /// <summary>
        /// True if the code is modifying components on the form
        /// </summary>
        private bool _working = true;
        #endregion

        public FilterGenerator()
        {
            InitializeComponent();
            _working = false;
        }

        #region events
        // for every change in the input, update the output
        // it may not be the most beautiful way to do it, but at this point the user won't notice
        private void artistsTextbox_TextChanged(object sender, EventArgs e)
        {
            updateOutput();
        }

        private void cbFilterRemix_CheckedChanged(object sender, EventArgs e)
        {
            updateOutput();
        }

        private void cbBitrate_CheckedChanged(object sender, EventArgs e)
        {
            updateOutput();
        }

        private void cbFilterLive_CheckedChanged(object sender, EventArgs e)
        {
            updateOutput();
        }

        private void bitratePicker_ValueChanged(object sender, EventArgs e)
        {
            updateOutput();
        }
        private void albumsTextbox_TextChanged(object sender, EventArgs e)
        {
            updateOutput();
        }

        private void whitelistDirsRB_CheckedChanged(object sender, EventArgs e)
        {
            updateOutput();
        }

        private void blacklistDirsRB_CheckedChanged(object sender, EventArgs e)
        {
            updateOutput();
        }

        private void directoriesTb_TextChanged(object sender, EventArgs e)
        {
            updateOutput();
        }

        private void OutputTextbox_MouseClick(object sender, MouseEventArgs e)
        {
            // put the output on the clipboard as plain text
            Clipboard.SetText(outputTextbox.Text);
            // notify the user that the clipboard has been modified
            MessageBox.Show("Text has been copied to clipboard.");
        }

        private void ExistingStringTextbox_TextChanged(object sender, EventArgs e)
        {
            // check if we are already working on the string to prevent loops and unneeded delays
            if (_working)
            {
                return;
            }
            _working = true;


            string text = existingStringTextbox.Text.Trim();
            if (text[0] == '(')
            {
                // if the text starts with an opening bracket, assume it is a filter
                interpretFilterString(text);
            }
            else
            {
                // when it is not a filter, just assume it is a string of artists
                interpretCopiedArtists(text);
            }

            // reset the string
            existingStringTextbox.Text = String.Empty;
            // reset the working variable to allow rerunning of the method
            _working = false;
            // update the output field now we're done interpreting
            updateOutput();
        }
        #endregion

        #region private methods
        /// <summary>
        /// Updates the output field based on the input fields
        /// </summary>
        private void updateOutput()
        {
            if (_working)
            {
                return;
            }
            _working = true;
            StringBuilder sb = new StringBuilder();


            // add every artist to the filter after sorting them
            artistsTextbox.SortLines();
            bool isFirst = true;
            foreach (string artist in artistsTextbox.Lines)
            {
                if (String.IsNullOrWhiteSpace(artist))
                {
                    continue;
                }
                if (isFirst)
                {
                    // put this before the artist fields
                    sb.Append("("); isFirst = false;
                }
                else { sb.Append(" OR "); }

                sb.AppendFormat(@"(Artist IS {0})", artist.Trim());
            }

            // add every album to the filter after sorting them
            albumsTextbox.SortLines();
            foreach (string album in albumsTextbox.Lines)
            {
                if (String.IsNullOrWhiteSpace(album))
                {
                    continue;
                }
                if (isFirst)
                {
                    // put this before the album field if there is no encapsulation yet
                    sb.Append("("); isFirst = false;
                }
                else { sb.Append(" OR "); }

                sb.AppendFormat(@"(Album IS {0})", album.Trim());
            }

            if (!isFirst)
            {
                // if there was at least one artist or album, put this at the end of the artist fields
                sb.Append(")");
            }

            // add every directory to the filter after sorting them
            directoriesTb.SortLines();
            string directoriesFormat = whitelistDirsRB.Checked ? @"(%directory% HAS {0})" : @"(NOT %directory% HAS {0})";
            foreach (string directory in directoriesTb.Lines)
            {
                if (String.IsNullOrWhiteSpace(directory))
                {
                    continue;
                }

                if (isFirst) { isFirst = false; }
                else { sb.Append(" AND "); }

                sb.AppendFormat(directoriesFormat, directory.Trim());
            }

            // if the filter live checkbox is checked, add the live filter
            if (cbFilterLive.Checked)
            {
                if (!isFirst) { sb.Append(" AND "); } else { isFirst = false; }
                sb.Append("(NOT Album HAS live) AND (NOT Comment HAS live)");
            }

            // if the remix checkbox is checked, add the remix filter
            if (cbFilterRemix.Checked)
            {
                if (!isFirst) { sb.Append(" AND "); } else { isFirst = false; }
                sb.Append("(NOT Title HAS remix)");
            }

            // if the bitrate checkbox is checked, add the bitrate filter
            if (cbBitrate.Checked)
            {
                if (!isFirst) { sb.Append(" AND "); } else { isFirst = false; }
                sb.AppendFormat(@"(%bitrate% GREATER {0})", (int)Math.Round(bitratePicker.Value));
            }

            // set the output
            outputTextbox.Text = sb.ToString();
            _working = false;
        }

        /// <summary>
        /// Interprets the given string as a filter. Assumes the filter is built up the same way this application would build it.
        /// </summary>
        /// <param name="text">Filter string</param>
        private void interpretFilterString(string text)
        {
            // interpret artists
            genericEntryProcessor(text, "(Artist IS ", artistsTextbox);

            // interpret albums
            genericEntryProcessor(text, "(Album IS ", albumsTextbox);

            // interpret directories
            // since we only interpret either a blacklist or a whitelist of directories, we choose what has the higher priority
            // I chose to go with a blacklist, that is the most natural when we have no entries
            int blackListEntries = genericEntryProcessor(text, @"(NOT %directory% HAS ", directoriesTb);
            if (blackListEntries > 0)
            {
                blacklistDirsRB.Checked = true;
            }
            else
            {
                int whitelistEntries = genericEntryProcessor(text, @"(%directory% HAS ", directoriesTb);
                if (whitelistEntries > 0)
                {
                    whitelistDirsRB.Checked = true;
                }
            }


            // interpret live filter
            string liveSearchStringStart = "(NOT ";
            string liveSearchStringEnd = "live)";
            int start = text.IndexOf(liveSearchStringStart);
            int end = text.IndexOf(liveSearchStringEnd);
            cbFilterLive.Checked = start >= 0 && end >= 0;
            text.Replace("(NOT Album HAS live)", "");
            text.Replace("(NOT Comment HAS live)", "");

            // interpret remix filter
            string remixFilter = "(NOT Title HAS remix)";
            start = text.IndexOf(remixFilter);
            cbFilterRemix.Checked = start >= 0;
            text.Replace(remixFilter, "");

            // interpret bitrate filter
            string bitrateSearchStringStart = @"(%bitrate% GREATER ";
            string bitrateSearchStringEnd = ")";
            start = text.IndexOf(bitrateSearchStringStart);
            if (start >= 0)
            {
                int bitrate = 0;
                string sub = text.Substring(start + bitrateSearchStringStart.Length);
                end = sub.IndexOf(bitrateSearchStringEnd);
                sub = sub.Substring(0, end);
                cbBitrate.Checked = int.TryParse(sub, out bitrate);
                bitratePicker.Value = bitrate;
            }
            else
            {
                cbBitrate.Checked = false;
            }
            text.Replace(bitrateSearchStringStart, "");
        }

        /// <summary>
        /// Processes all the hits in the text for the search into the provided textbox
        /// Returns the number of processed entries
        /// </summary>
        /// <param name="text">The text to search through</param>
        /// <param name="search">The start of the entry to search for</param>
        /// <param name="tb">The textbox that will contain the entries</param>
        /// <returns>Number of processed entries</returns>
        private int genericEntryProcessor(string text, string search, TextBox tb)
        {
            int retVal = 0;
            int closingBracketIndex = 0;
            string subText = String.Empty;
            for (int i = text.IndexOf(search); i >= 0; i = text.IndexOf(search))
            {
                closingBracketIndex = text.Substring(i + search.Length).IndexOf(')');
                subText = text.Substring(i + search.Length, closingBracketIndex);
                tb.AppendLine(subText);
                text = text.Replace(search + subText + ')', "").Trim();
                retVal++;
            }
            return retVal;
        }

        /// <summary>
        /// Interprets the given string as artists with semicolon separators
        /// </summary>
        /// <param name="text">Artists separated by semicolons</param>
        private void interpretCopiedArtists(string text)
        {
            // split on the separator
            string[] artists = text.Split(';');
            foreach (string artist in artists)
            {
                if (String.IsNullOrWhiteSpace(artist))
                {
                    // if the string is empty, just ignore it
                    continue;
                }

                if (!artistsTextbox.Text.Contains(artist.Trim()))
                {
                    // check of the artist is already defined. If it is not, add it
                    artistsTextbox.AppendLine(artist.Trim());
                }
            }
        }
        #endregion



    }

    public static class WinFormsExtensions
    {
        /// <summary>
        /// Appends the provided value to the textbox on a new line
        /// </summary>
        /// <param name="source">Textbox to add the line to</param>
        /// <param name="value">Value to be appended on a new line</param>
        public static void AppendLine(this TextBox source, string value)
        {
            if (source.Text.Length == 0)
                // if there is no text in the box, don't add a line
                source.Text = value;
            else
                source.AppendText(String.Format("\r\n{0}", value));
        }

        /// <summary>
        /// Sorts the lines of the textbox while keeping the caret position on the same row
        /// Assumes no two rows are the same, but if they are, the user will probably not notice anything
        /// </summary>
        /// <param name="source">Textbox of which the lines should be sorted</param>
        public static void SortLines(this TextBox source)
        {
            if (String.IsNullOrWhiteSpace(source.Text))
            {
                // if there is no text, jump out early to prevent needles cycles and possible crashes
                return;
            }

            // pry the lines loose from the textbox
            string[] lines = source.Lines;
            // get the string the user is working on
            string workingString = lines[source.GetLineFromCharIndex(source.SelectionStart)];
            // get the index of the caret within that string
            int caretIndex = source.SelectionStart - source.GetFirstCharIndexOfCurrentLine();
            // sort the acquired lines
            Array.Sort<string>(lines);
            // join the lines with linebreaks in between to break them up in lines again
            // yes, this may sound a bit odd and needless
            // but we do this to update the textbox component in the way it expects to be updated
            // this way we prevent any irregularities that may arise from future changes to the component
            source.Text = String.Join("\r\n", lines);
            // find the line we were working on
            int line = Array.IndexOf<string>(source.Lines, workingString);
            // set the caret to the correct index of the line we were working on
            source.SelectionStart = source.GetFirstCharIndexFromLine(line) + caretIndex;
        }
    }
}
