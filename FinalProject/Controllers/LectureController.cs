using Common.Dtos;
using MediaToolkit.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using MyProject.Service.Interfaces;
using System;
using System.IO;
using TagLib;
using MediaToolkit;



namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly IService<LectureDto> service;
        public LectureController(IService<LectureDto> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<List<LectureDto>> Get()
        {
            return await service.GetAllAsync();
        }

        //[HttpGet("GetPodcastsOfCategory/{categoryId}")]
        //public async Task<IActionResult> GetPodcastsOfCategory(int categoryId)
        //{
        //    List<LectureDto> allPodcasts = await service.GetAllAsync();
        //    var categoryPodcasts = allPodcasts.Where(x => x.CategoryId == categoryId);
        //    return Ok(new { success = true, data = categoryPodcasts });
        //}

        [HttpGet("GetPodcastsOfLecturer/{lecturerId}")]
        public async Task<IActionResult> GetPodcastsOfCategory(int lecturerId)
        {
            List<LectureDto> allPodcasts = await service.GetAllAsync();
            var lecturerPodcasts = allPodcasts.Where(x => x.LecturerId == lecturerId);
            return Ok(new { success = true, data = lecturerPodcasts });
        }

        [HttpGet("GetPodcastsOfUser/{userId}")]
        public async Task<IActionResult> GetPodcastsOfUser(int userId)
        {
            List<LectureDto> allPodcasts = await service.GetAllAsync();
            var userPodcasts = allPodcasts.Where(x => x.UserId == userId);
            return Ok(new { success = true, data = userPodcasts });
        }
        [HttpGet("MaxViews")]
        public async Task<IActionResult> GetMaxViews()
        {
            var lectures = await service.GetAllAsync();
            var maxViews = lectures.OrderByDescending(l => l.NumberViews).Take(7);
            return Ok(new { success = true, data = maxViews });
        }

        private IActionResult DownloadVideo(string fileName)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "Video/", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            // **New code to set content type based on extension**
            var fileExtension = Path.GetExtension(fileName).ToLowerInvariant();
            var contentType = "application/octet-stream";

            if (fileExtension == ".mp3")
            {
                contentType = "audio/mp3";
            }
            else if (fileExtension == ".mp4")
            {
                contentType = "video/mp4";
            }

            return File(fileBytes, contentType, fileName);
        }


        [HttpGet("getPodcast/{PodcastUrl}")]
        public string GetPodcast(string PodcastUrl)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Video", PodcastUrl);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string podcastBase64 = Convert.ToBase64String(bytes);
            string podcast = string.Format("data:image/jpeg;base64,{0}", podcastBase64);
            return podcast;
        }
        [HttpGet("getImagePodcast/{PodcastUrl}")]
        public byte[] imageExtraction(string PodcastUrl)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Video", PodcastUrl);

            try
            {
                using (var file = TagLib.File.Create(path))
                {
                    var tag = file.Tag;
                    if (tag.Pictures.Length >= 1)
                    {
                        var first = tag.Pictures[0];
                        return first.Data.Data;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
      

        [HttpPost]

        public async Task<IActionResult> UploadVideoAsync([FromForm] LectureDto lectureDto)
        {

            if (lectureDto.LectureFile == null || lectureDto.LectureFile.Length <= 0)
            {
                return BadRequest("No file uploaded");
            }
            var originalFileName = lectureDto.LectureFile.FileName;

    
            var filePath = Path.Combine(Environment.CurrentDirectory, "Video/", originalFileName);



            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                lectureDto.LectureFile.CopyTo(stream);
            }
            lectureDto.UrlLectureFile = lectureDto.LectureFile.FileName;

            //using (var stream = new FileStream(filePath, FileMode.Open))
            //{
            //    using (var mediaFile = new MediaFile(filePath))
            //    {
            //        var duration = mediaFile.Metadata.Duration;
            //        // אחזור דקות מהמשך
            //        int minutes = (int)duration.TotalMinutes;

            //        // שמור דקות ב-lectureDto או במקום אחר לפי הצורך
            //        lectureDto.LengthOfLecture = minutes.ToString();
            //    }
            //}
            //using(var stream=new FileStream(filePath, FileMode.Open)) { 
            //    using(var mediaFile=new MediaFile(filePath))
            //    {
            //        var duration=mediaFile.Metadata.Duration;
            //        int minutes=(int)duration.TotalMinutes;
            //        lectureDto.LengthOfLecture = minutes.ToString();
            //    } 
            //}
                //using (var stream = new FileStream(filePath, FileMode.Open))
                //{
                //    var mediaFile = new MediaFile(filePath); // No using block needed here
                //    var duration = mediaFile.Metadata.Duration;
                //    int minutes = (int)duration.TotalMinutes;
                //    lectureDto.LengthOfLecture = minutes.ToString();
                //}

           


            await service.AddAsync(lectureDto);

            return Ok("Video uploaded successfully");
        }
        [HttpGet("{id}")]
        public async Task<LectureDto> Get(int id)
        {
            
            var lecture = await service.GetByIdAsync(id);
            if(lecture.isVideo==true)
            {
                return lecture;
            }
            
            //lecture.UrlPictureFile = imageExtraction(lecture.UrlLectureFile);
            //lecture.SimpleUrl = lecture.UrlLectureFile;
            //lecture.UrlLectureFile = GetPodcast(lecture.UrlLectureFile);
            //LectureDto lecture = await service.GetByIdAsync(id);
            return lecture;
            //return DownloadVideo(lecture.UrlLectureFile);
        }

        [HttpGet("download/{id}")]

        public async Task<IActionResult> GetDownloadPodcast(int id)
        {


            LectureDto lecture = await service.GetByIdAsync(id);

            return DownloadVideo(lecture.UrlLectureFile);
        }


        [HttpPut("{id}")]
        public async Task Put(int id, [FromForm] LectureDto value)
        {
            //var myPath = Path.Combine(Environment.CurrentDirectory + "/Video/" + value.LectureFile.FileName);
            //using (FileStream fs = new FileStream(myPath, FileMode.Create))
            //{
            //    value.LectureFile.CopyTo(fs);
            //    fs.Close();
            //}
            //value.UrlLectureFile = value.LectureFile.FileName;
            await service.UpdateAsync(id, value);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }


    }
}







