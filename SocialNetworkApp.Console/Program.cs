using Figgle;
using SocialNetworkApp.Console;
using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Infrastructure;


SeedData seedData = new SeedData();

Console.WriteLine(FiggleFonts.Standard.Render("SocialNetworkApp")); // Just to show off


// Find Profile By Id = 1
using (var uow = new UnitOfWork())
{
    var profile = await uow.ProfileRepository.FindByIdAsync(1);

    Console.WriteLine($"-> By {profile.FullName}, {profile.Description}\n");
}


// Find or Create a Post, and display all posts
using (var uow = new UnitOfWork())
{
    foreach(var post in seedData.PostList)
    {
        await uow.PostRepository.FindOrCreateAsync(post);
        await uow.SaveAsync();
    }
    
    Console.WriteLine("\na) All existing Products");
    Console.WriteLine(new string('-', 55));

    var existingPosts = await uow.PostRepository.FindAllAsync();
    foreach (var instance in existingPosts)
    {
        Console.WriteLine($"- {instance.Id} -> {instance.Author.FirstName} | \"{instance.Title}\" | \"{instance.Description}\", {instance.PostedAt} ");
    }
    

    var searchKeyWord = "O aluno";
    Console.WriteLine($"\n\nb) Find Product By part of the title : \" {searchKeyWord} \" ");
    Console.WriteLine(new string('-', 55));
    
    var results = await uow.PostRepository.FindAllPostsByTitleStartingWithAsync(searchKeyWord);
    foreach (var result in results)
    {
        Console.WriteLine($"result : \"{result.Title}\" ");
    }
}


// Find Or Creete a Tag, and display all tags
using (var uow = new UnitOfWork())
{
    foreach (var tag in seedData.TagList)
    {
        await uow.TagRepository.FindOrCreateAsync(tag);
        await uow.SaveAsync();
    }

    var existingTags = await uow.TagRepository.FindAllAsync();

    Console.WriteLine($"\n\nc) All existing {nameof(Tag)}");
    Console.WriteLine(new string('-', 55));
    Console.WriteLine("- ID -> Name");

    foreach (var instance in existingTags)
    {
        Console.WriteLine($"- {instance.Id} -> {instance.Name} ");
    }
}

// Find Or Create a relation TagPost
// Find a Post by Id
// Display all tags associated with the Post
using (var uow = new UnitOfWork())
{
    foreach (var tagPost in seedData.TagPostList)
    {
        await uow.TagPostRepository.FindOrCreateAsync(tagPost);
        await uow.SaveAsync();
    }

    var post = await uow.PostRepository.FindByIdAsync(1);

    Console.WriteLine($"\n\nd) Post with the title \"{post.Title}\" has this Tags associated");
    Console.WriteLine(new string('-', 55));
    Console.WriteLine("- ID -> Name");

    foreach (var instance in post.TagsPosts)
    {
        Console.WriteLine($"- {instance.Tag.Id} -> {instance.Tag.Name} ");
    }
}


// Find Or Create Comments
// Find all Comments of the Post with Id = 1
// Display them
using (var uow = new UnitOfWork())
{
    foreach (var instance in seedData.CommentList)
    {
        await uow.CommentRepository.FindOrCreateAsync(instance);
        await uow.SaveAsync();
    }

    Console.WriteLine($"\n\ne) Comments Of Post with Id = 1");
    Console.WriteLine(new string('-', 55));
    
    var comments = await uow.CommentRepository.FindAllCommentsByPostIdAsync(1);
    foreach (var comment in comments)
    {
        Console.WriteLine($"- Post : {comment.Post.Title} \n Comentarios: \n O {comment.Author.FullName} commentou \"{comment.Content}\" ");
    }
}

// Find Or Create a User and a Profile for that user
// Display all user and profile info
using (var uow = new UnitOfWork())
{
    foreach (var instance in seedData.UserList)
    {
        await uow.UserRepository.FindOrCreateAsync(instance);
        await uow.SaveAsync();
    }
    
    foreach (var instance in seedData.ProfileList)
    {
        await uow.ProfileRepository.FindOrCreateAsync(instance);
        await uow.SaveAsync();
    }

    var searchKeyWord = "bernardo"; // this is a username
    var user = await uow.UserRepository.FindByUsernameAsync(searchKeyWord);
    var profile = await uow.ProfileRepository.FindByIdAsync(user.Id);

    Console.WriteLine($"\n\nf) User with username \"{searchKeyWord}\" ");
    Console.WriteLine(new string('-', 55));

    if (user != null && profile != null)
    {
        Console.WriteLine($"User with Id = {user.Id} Info:\n - Username: {user.Username},\n - Password: {user.Password}");
        Console.WriteLine($"Has the following Profile Info:\n - Full Name : {profile.FullName},\n - Description : {profile.Description}\n");
    }
}

// Find Or Create a Friendship
// Display all friendships of a profile id
using (var uow = new UnitOfWork())
{
    foreach (var instance in seedData.Friendships)
    {
        await uow.FriendshipRepository.FindOrCreateAsync(instance);
        await uow.SaveAsync();
    }
    
    Console.WriteLine($"\n\ng) Friendships of user with profileId = 2");
    Console.WriteLine(new string('-', 55));
    
    var friendships = await uow.FriendshipRepository.FindAllFriendshipsByProfileIdAsync(2);
    foreach (var friendship in friendships)
    {
        Console.WriteLine($"- {friendship.Friend.Id} -> {friendship.Friend.FullName}");
    }

}

