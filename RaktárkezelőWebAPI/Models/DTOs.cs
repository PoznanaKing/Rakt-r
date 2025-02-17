namespace RaktárkezelőWebAPI.Models
{
    public record UploadBeszallitoDTO(string name);
    public record DeleteBeszallitoDTO(int id);
    public record EditBeszallitoDTO(string name, int id);
    public record GetBeszallitoDTO(int id, string name);
}
