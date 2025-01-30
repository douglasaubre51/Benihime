using System;
using CloudinaryDotNet.Actions;

namespace Benihime.Interfaces;

public interface IPhotoService
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    Task<DeletionResult> DeletePhotoAsync(String publicId);
}
