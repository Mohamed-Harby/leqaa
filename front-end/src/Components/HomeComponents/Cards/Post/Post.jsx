import React, { useState } from "react";
import RadiusImg from "../../../RadiusImg/RadiusImg";
import "./Post.css";

const MAX_COLLAPSED_CHARS = 300;

const Post = ({ post }) => {
  const [isExpanded, setIsExpanded] = useState(false);

  const toggleExpand = () => {
    setIsExpanded(!isExpanded);
  };

  const getContent = () => {
    if (isExpanded) {
      return post.content;
    } else if (post.content.length > MAX_COLLAPSED_CHARS) {
      return post.content.substring(0, MAX_COLLAPSED_CHARS) + "...";
    } else {
      return post.content;
    }
  };

  return (
    <div className="post">
      <div className="header">
        <div className="creatorSection">
          <RadiusImg
            img={post?.image ? "data:image/png;base64," + post.image : null}
            size={40}
          />
          <span className="creatorName">{post.creator.name}</span>
        </div>
        <div>{post.postTime}</div>
      </div>
      <div className="postText">
        <p className={isExpanded ? "content expanded" : "content collapsed"}>
          {getContent()}
          {post.content.length > MAX_COLLAPSED_CHARS && (
            <span onClick={toggleExpand} className="seeMoreButton">
              {isExpanded ? "see less" : "see more"}
            </span>
          )}
        </p>
      </div>
      <div className="reactions">
        <div className="reaction">
          <span>Like</span>
        </div>
        <div className="reaction">
          <span>Dislike</span>
        </div>
      </div>
    </div>
  );
};

export default Post;
