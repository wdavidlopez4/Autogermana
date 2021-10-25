using Autogermana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autogermana.Domain.Ports
{
    public interface IRepository
    {
        /// <summary>
        /// guarda objeto en la db
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> Save<T>(T obj, CancellationToken cancellationToken) where T : Entity;

        /// <summary>
        /// verifica si existe el obj
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity;

        /// <summary>
        /// retorna un objeto, el primero en cumplir el predicado
        /// debe pararse datos unicos como el id, ya que, solo devolvera el primer objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> Get<T>(Expression<Func<T, bool>> expression,
            CancellationToken cancellationToken) where T : Entity;

        /// <summary>
        /// modifica un objeto que tenga el mismo identificador
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> Update<T>(T obj, CancellationToken cancellationToken) where T : Entity;
    }
}
