using DevExpress.Xpo.Metadata;
using System;

namespace ODataService.ValueConverters
{
    public class GeneralDateTimeConverter : ValueConverter
    {
        public override object ConvertFromStorageType(object value)
        {
            object result = null;
            if (value != null)
            {
                result = DateTime.SpecifyKind((DateTime)value, DateTimeKind.Utc).ToLocalTime();
            }
            return result;
        }

        public override object ConvertToStorageType(object value)
        {
            object result = null;
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Kind == DateTimeKind.Unspecified)
                {
                    result = DateTime.SpecifyKind(date, DateTimeKind.Local).ToUniversalTime();
                }
                else if (date.Kind == DateTimeKind.Local)
                {
                    result = (object)date.ToUniversalTime();
                }
                else
                {
                    result = (object)date;
                }
            }
            return result;
        }

        public override Type StorageType { get { return typeof(DateTime); } }
    }

}
