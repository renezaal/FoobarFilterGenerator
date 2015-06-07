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

        private void OutputTextbox_MouseClick(object sender, MouseEventArgs e)
        {
            // put the output on the clipboard as plain text
            Clipboard.SetText(OutputTextbox.Text);
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


            string text = ExistingStringTextbox.Text.Trim();
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
            ExistingStringTextbox.Text = String.Empty;
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


            // add every artist to the filter
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

            if (!isFirst)
            {
                // if there was at least one artist, put this at the end of the artist fields
                sb.Append(")");
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
            OutputTextbox.Text = sb.ToString();
            _working = false;
        }

        /// <summary>
        /// Interprets the given string as a filter. Assumes the filter is built up the same way this application would build it.
        /// </summary>
        /// <param name="text">Filter string</param>
        private void interpretFilterString(string text)
        {
            // interpret artists
            string artistSearchString = "(Artist IS ";
            for (int i = text.IndexOf(artistSearchString); i >= 0; i = text.IndexOf(artistSearchString))
            {
                int closingBracketIndex = text.Substring(i + artistSearchString.Length).IndexOf(')');
                string subText = text.Substring(i + artistSearchString.Length, closingBracketIndex);
                artistsTextbox.AppendLine(subText);
                text = text.Replace(artistSearchString + subText + ')', "").Trim();
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
    }
}
