using DotNetNuke.Common.Utilities;

namespace ICG.Modules.SimpleBootstrapAccordion.Components.Utility
{
    /// <summary>
    ///     Wrapper for working with DNN Cache
    /// </summary>
    public static class CacheUtility
    {
        /// <summary>
        ///     Does the item exist in the cache?
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool CacheExists(string key)
        {
            return DataCache.GetCache(key) != null;
        }

        /// <summary>
        ///     Sets the cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toSet">To set.</param>
        /// <param name="key">The key.</param>
        public static void SetCache<T>(T toSet, string key)
        {
            DataCache.SetCache(key, toSet);
        }

        /// <summary>
        ///     Gets the item from cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static T GetItemFromCache<T>(string key)
        {
            return (T) DataCache.GetCache(key);
        }
    }
}