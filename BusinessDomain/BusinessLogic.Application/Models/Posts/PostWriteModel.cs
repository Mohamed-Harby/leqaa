namespace BusinessLogic.Application.Models.Posts;
public record PostWriteModel(
    string Title,
    byte[]? Image,
   string Content,
    string Username
);