using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace ContactsFluentMVVM.Domain
{
    public class People
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Company { get; set; }
        public virtual string Telephone { get; set; }
        public virtual string Email { get; set; }
        public virtual bool? Client { get; set; }
        public virtual DateTime? LastCall { get; set; }
    }

    public class PeopleMap : ClassMap<People>
    {
        public PeopleMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(100).Nullable();
            Map(x => x.Company).Length(100).Nullable();
            Map(x => x.Telephone).Length(100).Nullable();
            Map(x => x.Email).Length(100).Nullable();
            Map(x => x.Client).Nullable();
            Map(x => x.LastCall).Nullable();
        }
    }
}
