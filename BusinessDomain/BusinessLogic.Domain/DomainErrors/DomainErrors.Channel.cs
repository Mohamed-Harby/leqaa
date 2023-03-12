using ErrorOr;

namespace BusinessLogic.Domain.DomainErrors;
public static partial class DomainErrors
{
    public static class Channel
    {
        public static Error NotFound => Error.NotFound("Channel.NotFound", "channel not found, create channel");
        public static Error InvalidChannel => Error.Failure(
            "Channel.InvalidChannel",
            "Invalid Channel, couldn't complete your request");
        public static Error AlreadyExist => Error.Failure("Channel.AlreadyExist", "Channel aleaready exists");
        public static Error CannotJoinChannel => Error.Failure(
            "Channel.CannotJoinChannel",
            "Could join you to this channel, please check your input");
        public static Error AlreadyPinned => Error.Conflict(
            "Channel.AlreadyPinned",
            "Channel is already pinned, please check your pinned channels list");
    }



    public static partial class Room
    {
        public static Error InvalidRoom => Error.Failure("Room.InvalidChannel", "Invalid Room, couldn't complete your request");
    }


    public static class Post
    {
        public static Error InvalidPost => Error.Failure("Post.InvalidPost", "Invalid Post, couldn't complete your request");
        public static Error NotFound => Error.NotFound("Post.NotFound", "post not found, create post");
        public static Error AllreadyExistsToPin => Error.NotFound("Post.AllreadyExistsToPin", "posts all ready Pinned");
    }
}