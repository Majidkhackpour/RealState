using System.Collections.Generic;
using System.Reflection;
using Services;

namespace User.AccessLevel
{
    public class PropertyInfoClass
    {
        private object _cls;
        private List<PropertyInfoClass> _ListPropInfo = null;
        private bool _invalidate = true;
        private bool? _CheckAllValue = null;
        public PropertyInfoClass(object cls)
        {
            _cls = cls;
        }
        public PropertyInfoClass(PropertyInfo propInfo, string persianName, string name, object cls)
        {
            this.propInfo = propInfo;
            Name = name;
            PersianName = persianName;
            _cls = cls;
        }
        public string PersianName { get; set; }
        public string Name { get; set; }
        public bool? Checked
        {
            get => propInfo.GetValue(_cls).ToString().ParseToBoolean();
            set
            {
                propInfo.SetValue(_cls, value);
                _invalidate = true;
            }
        }

        public PropertyInfo propInfo { get; set; }

        public List<PropertyInfoClass> ListInfo
        {
            get
            {
                if (ReferenceEquals(_ListPropInfo, null))
                {
                    _ListPropInfo = new List<PropertyInfoClass>();
                    foreach (var prop in _cls.GetType().GetProperties())
                    {

                        object[] attrs = prop.GetCustomAttributes(true);
                        foreach (object attr in attrs)
                        {
                            if (attr is PersianNameAttribute.PersianName pname)
                            {
                                _ListPropInfo.Add(new PropertyInfoClass(prop, pname.Text, prop.Name, _cls));
                                break;
                            }
                        }


                    }
                }
                return _ListPropInfo;
            }
        }

        public bool? CkeckAll
        {
            get
            {
                if (_invalidate)
                {
                    var allComplete = false;
                    var allNoComplete = false;
                    foreach (var item in ListInfo)
                    {
                        if (item.Checked.HasValue)
                            if (item.Checked.Value) allComplete = true;
                            else allNoComplete = true;
                    }
                    if (allComplete && allNoComplete)
                        _CheckAllValue = null;
                    if (allComplete && !allNoComplete)
                        _CheckAllValue = true;
                    if (!allComplete && allNoComplete)
                        _CheckAllValue = false;
                }
                _invalidate = false;
                return _CheckAllValue;
            }
            set
            {
                if (!value.HasValue)  return;
                foreach (var item in ListInfo)
                    item.Checked = value;
                _invalidate = true;
            }
        }

    }
}
