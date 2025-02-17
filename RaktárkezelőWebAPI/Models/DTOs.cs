namespace RaktárkezelőWebAPI.Models
{
    public record UploadBeszallitoDTO(string name);
    public record DeleteBeszallitoDTO(int id);
    public record EditBeszallitoDTO(string name, int id);
    public record GetBeszallitoDTO(int id, string name);



    public record UploadTermekDTO(string name, int ar, int beszallitoid);
    public record DeleteTermekDTO(int id);
    public record EditTermekDTO(int id, string name, int ar, int beszallitoid);
}
