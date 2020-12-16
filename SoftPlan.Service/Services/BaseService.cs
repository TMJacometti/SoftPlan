using FluentValidation;
using SoftPlan.Domain.Entities;
using SoftPlan.Domain.Interfaces;
using SoftPlan.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlan.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            // JÁ QUE TODAS AS MODELS TEM O CAMPO DATACADASTRO, DEFINIMOS A DATA AQUI
            obj.DataCadastro = DateTime.Now;

            repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            // JÁ QUE TODAS AS MODELS TEM O CAMPO DATACADASTRO, ATUALIZAMOS A DATA AQUI
            obj.DataCadastro = DateTime.Now;

            repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id não pode ser zero");

            repository.Delete(id);
        }

        public IList<T> Get() => repository.Select();

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id não pode ser zero");

            return repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Objeto Nullo !");

            validator.ValidateAndThrow(obj);
        }
    }
}
