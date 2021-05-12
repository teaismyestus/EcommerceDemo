using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PropertyManager : IPropertyService
    {
        private IPropertyDal _propertyDal;
        public PropertyManager(IPropertyDal propertyDal)
        {
            _propertyDal = propertyDal;
        }
        public List<Property> GetAll()
        {
            return _propertyDal.GetList();
        }
    }
}
