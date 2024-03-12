using DTOs.Responses;
using DTOs;

namespace Services.Abstractions
{
    public interface IResourceService
    {
        Task<MainResponce<ListResponse<List<ResourceDTO>>>> GetListResourse();

        Task<MainResponce<BaseResponse<ResourceDTO>>> GetResourceById(int id);

        public void PrintSingleResource(MainResponce<BaseResponse<ResourceDTO>> responce, int id);

        public void PrintResource(ResourceDTO resource);
    }
}
