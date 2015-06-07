using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoobarFilterGenerator
{
    public partial class FilterGenerator : Form
    {
        public FilterGenerator()
        {
            InitializeComponent();
            working = false;
        }

        private void artistsTextbox_TextChanged(object sender, EventArgs e)
        {
            updateOutput();
        }

        private void updateOutput()
        {
            if (working)
            {
                return;
            }
            working = true;
            StringBuilder sb = new StringBuilder();

            sb.Append("(");

            for (int i = 0; i < artistsTextbox.Lines.Length; i++)
            {
                string artist = artistsTextbox.Lines[i];
                if (i != 0)
                {
                    sb.Append(" OR ");
                }

                artist = artist.Trim();

                sb.AppendFormat(@"(Artist IS {0})", artist);
            }

            sb.Append(")");

            if (cbFilterLive.Checked)
            {
                sb.Append(" AND (NOT Album HAS live) AND (NOT Comment HAS live)");
            }

            if (cbFilterRemix.Checked)
            {
                sb.Append(" AND (NOT Title HAS remix)");
            }

            if (cbBitrate.Checked)
            {
                sb.AppendFormat(@" AND (%bitrate% GREATER {0})", (int)Math.Round(bitratePicker.Value));
            }

            OutputTextbox.Text = sb.ToString();
            working = false;
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
            Clipboard.SetText(OutputTextbox.Text);
            MessageBox.Show("Text has been copied to clipboard.");
        }

        private bool working = true;
        private void ExistingStringTextbox_TextChanged(object sender, EventArgs e)
        {
            // check if we are already working on the string to prevent loops and unneeded delays
            if (working)
            {
                return;
            }
            working = true;


            string text = ExistingStringTextbox.Text.Trim();
            if (text[0] == '(')
            {
                interpretFilterString(text);
            }
            else
            {
                interpretCopiedArtists(text);
            }

            // reset the string
            ExistingStringTextbox.Text = String.Empty;
            // reset the working variable to allow rerunning of the method
            working = false;
            // update the output field now we're done interpreting
            updateOutput();
        }
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

        private void interpretCopiedArtists(string text)
        {
            string[] artists = text.Split(';');
            foreach (string artist in artists)
            {
                if (String.IsNullOrWhiteSpace(artist))
                {
                    continue;
                }
                if (!artistsTextbox.Text.Contains(artist.Trim()))
                {
                    artistsTextbox.AppendLine(artist.Trim());
                }
            }
        }
    }

    public static class WinFormsExtensions
    {
        public static void AppendLine(this TextBox source, string value)
        {
            if (source.Text.Length == 0)
                source.Text = value;
            else
                source.AppendText(String.Format("\r\n{0}", value));
        }
    }
}
