using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleGuideTutorial.Context;
using SimpleGuideTutorial.DTO.Description;
using SimpleGuideTutorial.Model;
using SimpleGuideTutorial.Services.Interface;

namespace SimpleGuideTutorial.Services
{
    public class DescriptionServices : IDescriptions
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;
        public DescriptionServices(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<DescriptionListDto>> SelectAllDescription(bool filterRemovedStatus)
        {
            var query = await (from d in _dbcontext.Descriptions
                               join c in _dbcontext.Categories on d.CategoryId equals c.Id
                               join i in _dbcontext.Images on d.ImageId equals i.Id into imageJoin
                               from img in imageJoin.DefaultIfEmpty()
                               join v in _dbcontext.Videos on d.VideoId equals v.Id into videoJoin
                               from vid in videoJoin.DefaultIfEmpty()
                               select new DescriptionListDto
                               {
                                   Id = d.Id,
                                   CategoryName = c.Name,
                                   Description = d.DescriptionText,
                                   ImagePath = img.Path,
                                   VideoPath = vid.Url,
                                   isRemoved = d.Removed
                               }).ToListAsync();
            if (filterRemovedStatus)
                query = query.Where(x => x.isRemoved == filterRemovedStatus).ToList();
            return _mapper.Map<List<DescriptionListDto>>(query);
        }

        public async Task<bool> InsertDescription(CreateDescriptionDTO createDescriptionDTO)
        {
            var descriptions = new Description
            {
                DescriptionText = createDescriptionDTO.DescriptionText,
                CategoryId = createDescriptionDTO.CategoryId,
                ImageId = createDescriptionDTO.ImageId > 0 ? createDescriptionDTO.ImageId : null,
                VideoId = createDescriptionDTO.VideoId > 0 ? createDescriptionDTO.VideoId : null,
                Removed = false
            };

            _dbcontext.Descriptions.Add(descriptions);
            var result = await _dbcontext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateDescription(int DescriptionId,UpdateDescriptionDTO updateDescriptionDTO)
        {
            var existingDescription = await _dbcontext.Descriptions.FindAsync(DescriptionId);
            if (existingDescription == null)
                return false;
            //_mapper.Map(updateDescriptionDTO, existingDescription);

            existingDescription.DescriptionText = updateDescriptionDTO.DescriptionText;
            existingDescription.CategoryId = updateDescriptionDTO.CategoryId;
            existingDescription.ImageId = updateDescriptionDTO.ImageId > 0 ? updateDescriptionDTO.ImageId : null;
            existingDescription.VideoId = updateDescriptionDTO.VideoId > 0 ? updateDescriptionDTO.VideoId : null;
            existingDescription.Removed = updateDescriptionDTO.isRemoved;

            _dbcontext.Descriptions.Update(existingDescription);
            var result = await _dbcontext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteDescription(int DescriptionId)
        {
            var existingDescription = await _dbcontext.Descriptions.FindAsync(DescriptionId);
            if(existingDescription == null)
                return false;
            existingDescription.Removed = true;
            _dbcontext.Descriptions.Update(existingDescription);
            var result = await _dbcontext.SaveChangesAsync();
            return result > 0;
        }

        public bool Existing(CreateDescriptionDTO createDescriptionDTO)
        {
            var result = _dbcontext.Descriptions.Where(x => x.DescriptionText == createDescriptionDTO.DescriptionText);
            if(result.Count() > 0)
                return true;
            return false;
        }
    }
}
