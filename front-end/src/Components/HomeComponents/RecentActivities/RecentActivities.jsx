import React from "react";
import Card from "../../Card/Card";
import CardJoinMeeting from "../Cards/Meeting/CardJoinMeeting";
import Post from "../Cards/Post/Post";
import "./RecentActivities.css";

function RecentActivities() {
  const arr = [
    {
      type: "post",
      postTime: "1 Day ago",
      content:
        "I just finished reading an amazing book called 'The Journey of a Lifetime'. It's a gripping story filled with unexpected twists and turns. Highly recommended! I just finished reading an amazing book called 'The Journey of a Lifetime'. It's a gripping story filled with unexpected twists and turns. Highly recommended! I just finished reading an amazing book called 'The Journey of a Lifetime'. It's a gripping story filled with unexpected twists and turns. Highly recommended! I just finished reading an amazing book called 'The Journey of a Lifetime'. It's a gripping story filled with unexpected twists and turns. Highly recommended!",
      creator: {
        name: "John Doe",
        image: "https://picsum.photos/200",
        username: "johndoe123",
      },
    },
    {
      type: "meeting",
      meetingTitle: "Monthly Book Club Meeting",
      meetingTime: "2 Days ago",
      creator: {
        name: "Bookworm Club",
        image: "https://picsum.photos/200",
        username: "bookwormclub",
      },
    },
    {
      type: "post",
      postTime: "3 Days ago",
      content:
        "Just attended a fascinating conference on artificial intelligence. The speakers were incredibly knowledgeable, and I learned a lot!",
      creator: {
        name: "Jane Smith",
        image: "https://picsum.photos/200",
        username: "janesmith87",
      },
    },
    {
      type: "meeting",
      meetingTitle: "Product Launch Event",
      meetingTime: "4 Days ago",
      creator: {
        name: "ABC Company",
        image: "https://picsum.photos/200",
        username: "abccompany2023",
      },
    },
    {
      type: "post",
      postTime: "5 Days ago",
      content:
        "Visited a beautiful art exhibition today. The artwork was stunning and truly captured the essence of human emotions.",
      creator: {
        name: "Michael Wilson",
        image: "https://picsum.photos/200",
        username: "michaelwilsonart",
      },
    },
    {
      type: "meeting",
      meetingTitle: "Project Management Workshop",
      meetingTime: "6 Days ago",
      creator: {
        name: "XYZ Consulting",
        image: "https://picsum.photos/200",
        username: "xyzconsulting2023",
      },
    },
    {
      type: "post",
      postTime: "1 Week ago",
      content:
        "Had an incredible hiking adventure this weekend. Explored breathtaking landscapes and experienced the beauty of nature firsthand.",
      creator: {
        name: "Emily Johnson",
        image: "https://picsum.photos/200",
        username: "emilyadventures",
      },
    },
    {
      type: "meeting",
      meetingTitle: "Entrepreneurship Panel Discussion",
      meetingTime: "1 Week ago",
      creator: {
        name: "Startup Hub",
        image: "https://picsum.photos/200",
        username: "startuphub2023",
      },
    },
    {
      type: "post",
      postTime: "2 Weeks ago",
      content:
        "Just finished a coding marathon, and I'm thrilled with the results. Building software from scratch is challenging but rewarding!",
      creator: {
        name: "Alex Turner",
        image: "https://picsum.photos/200",
        username: "codegenius",
      },
    },
    {
      type: "meeting",
      meetingTitle: "Artificial Intelligence Conference",
      meetingTime: "2 Weeks ago",
      creator: {
        name: "Tech Innovators",
        image: "https://picsum.photos/200",
        username: "techinnovators2023",
      },
    },
    {
      type: "post",
      postTime: "3 Weeks ago",
      content:
        "Attended a thought-provoking seminar on sustainable living. It's essential for us to make conscious choices and protect our planet.",
      creator: {
        name: "Sophia Anderson",
        image: "https://picsum.photos/200",
        username: "sophiaeco",
      },
    },
    {
      type: "meeting",
      meetingTitle: "Web Development Workshop",
      meetingTime: "3 Weeks ago",
      creator: {
        name: "Code Masters",
        image: "https://picsum.photos/200",
        username: "codemasters2023",
      },
    },
    {
      type: "post",
      postTime: "1 Month ago",
      content:
        "Finished reading a captivating mystery novel. The plot kept me guessing until the very end. Can't wait to read more from this author!",
      creator: {
        name: "David Thompson",
        image: "https://picsum.photos/200",
        username: "mysterylover",
      },
    },
    {
      type: "meeting",
      meetingTitle: "Marketing Strategy Conference",
      meetingTime: "1 Month ago",
      creator: {
        name: "Marketing Gurus",
        image: "https://picsum.photos/200",
        username: "marketinggurus2023",
      },
    },
  ];

  return (
    <div className="recentactivities">
      {arr.map((item, index) => {
        if (item.type == "post") {
          return <Post key={index} post={item} />;
        } else {
          // return <CardJoinMeeting key={index} meeting={item} />;
        }
      })}
    </div>
  );
}

export default RecentActivities;
