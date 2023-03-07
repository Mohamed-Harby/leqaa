import React from "react";
import "./Post.css";

const Post = ({ card }) => {
  return (
    <div className="post">
      <div className="header">
        <h2>{card.postTitle}</h2>
        <div>{card.postTime}</div>
      </div>
      <p className="footer">{card.postDescription}</p>
    </div>
  );
};

export default Post;
