using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WordWizApp.Models
{
    public class GroupedButtonPartial
    {
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }

        public int? WordId { get; set; }
        public int? SentenceId { get; set; }
        public int? UserId { get; set; }
        public int? StudentId { get; set; }
        public int? MembershipTypeId { get; set; }


        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");

                if (WordId != null && WordId > 0)
                {
                    param.Append(String.Format(($"{WordId}")));
                }

                if (SentenceId != null && SentenceId > 0)
                {
                    param.Append(String.Format(($"{SentenceId}")));
                }

                if (UserId != null && UserId > 0)
                {
                    param.Append(String.Format(($"{UserId}")));
                }

                if (StudentId != null && StudentId > 0)
                {
                    param.Append(String.Format(($"{StudentId}")));
                }

                if (MembershipTypeId != null && MembershipTypeId > 0)
                {
                    param.Append(String.Format(($"{MembershipTypeId}")));
                }

                return param.ToString();
            }
        }

    }
}