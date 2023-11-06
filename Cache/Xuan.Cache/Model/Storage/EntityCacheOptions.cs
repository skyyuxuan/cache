using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache.Model.Storage
{
    /// <summary>
    /// EntityCacheOption
    /// </summary>
    public class EntityCacheOptions
    {
        /// <summary>
        /// Constructor
        /// </summary>
        private EntityCacheOptions()
        {

        }
        /// <summary>
        /// EntityName
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Serializer
        /// </summary>
        public string Serializer { get; set; }

        public class Builder
        {
            private EntityCacheOptions options = new EntityCacheOptions()
            {

            };

            /// <summary>
            ///  EntityName
            /// </summary>
            /// <param name="entityName"></param>
            /// <returns></returns>
            public Builder EntityName(string entityName)
            {
                options.EntityName = entityName;
                return this;
            }

            /// <summary>
            ///  Serializer
            /// </summary>
            /// <param name="serializer"></param>
            /// <returns></returns>
            public Builder Serializer(string serializer)
            {
                options.Serializer = serializer;
                return this;
            }

            /// <summary>
            /// Build
            /// </summary>
            /// <returns></returns>
            public EntityCacheOptions Build()
            {
                return options;
            }
        }
    }
}
