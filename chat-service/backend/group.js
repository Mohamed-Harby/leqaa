const message = {
  Name: "friends",
  IsPrivate: false,
  Description: "daily meetings",
  Image: null,
  ChannelAnnouncements: [],
  JoinedUsers: [
    {
      Name: "amoor",
      Email: "yicosar374@pixiil.com",
      UserName: "amoor",
      IsFollowed: false,
      ProfilePicture: null,
      Id: "81ddcceb-9fe6-46ea-b6e2-6fb84e5f0252",
      CreationDate: "2023-04-15T18:01:53.512333",
    },
    {
      Name: "amoor",
      Email: "yicosar374@pixiil.com",
      UserName: "amoor",
      IsFollowed: false,
      ProfilePicture: null,
      Id: "81ddcceb-9fe6-46ea-b6e2-6fb84e5f0252xxx",
      CreationDate: "2023-04-15T18:01:53.512333",
    },
  ],
  Id: "08db5000-5132-47b0-80ad-fe14e680a459",
  CreationDate: "0001-01-01T00:00:00",
};


// Extract the JoinedUsers' Ids
const joinedUsersIds = message.JoinedUsers.map(user => user.Id);

console.log(joinedUsersIds)
// Create an object with the JoinedUsers' Ids
// const idsObject = { users: joinedUsersIds };
// // const idsObject = JSON.parse(joinedUsersIds)

// console.log(idsObject)

// // Convert the object to JSON
// const jsonObject = JSON.stringify(idsObject);

// // Print the JSON object
// console.log(jsonObject);

// const body = {
//   name: "Test Group",
//   users:
//     '["95374890-c023-11ed-8d86-4deca82df8b","ac15f370-bada-11ed-86f5-a31d296d4fce"]',
// };
// const obj = JSON.parse(body.users)
// console.log('😂',obj)