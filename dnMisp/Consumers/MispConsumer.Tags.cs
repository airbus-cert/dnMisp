using dnMisp.Enums;
using dnMisp.Objects;
using System.Threading.Tasks;

namespace dnMisp
{
    public partial class MispConsumer
    {
        #region Tags

        public async Task<string> AddTag(TagRequest tag)
        {
            return await PostAsync("/tags/add", tag);
        }

        public async Task<string> RemoveTag(Tag tag)
        {
            return await PostAsync("/events/removeTag", new TagRequest(tag));
        }

        #endregion

    }
}
