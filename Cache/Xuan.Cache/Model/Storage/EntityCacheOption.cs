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
    public class EntityCacheOption
    {
        /// <summary>
        /// Constructor
        /// </summary>
        private EntityCacheOption()
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
            private EntityCacheOption option = new EntityCacheOption()
            {

            };

            /// <summary>
            ///  EntityName
            /// </summary>
            /// <param name="entityName"></param>
            /// <returns></returns>
            public Builder EntityName(string entityName)
            {
                option.EntityName = entityName;
                return this;
            }

            /// <summary>
            ///  Serializer
            /// </summary>
            /// <param name="serializer"></param>
            /// <returns></returns>
            public Builder Serializer(string serializer)
            {
                option.Serializer = serializer;
                return this;
            }

            /// <summary>
            /// Build
            /// </summary>
            /// <returns></returns>
            public EntityCacheOption Build()
            {
                return option;
            }
        }
    }
}
