import React from "react";
import RadiusImg from "../../../RadiusImg/RadiusImg";
import "./Post.css";

const Post = ({ card }) => {
  return (
    <div className="post">
      <div className="header">
        <h2>
          <RadiusImg
            img={card?.image ? "data:image/png;base64," + card.image : null}
            size={40}
          />
          {card.title}
        </h2>
        <div>{card.creationDate}</div>
      </div>
      <p className="footer">{card.content}</p>
      <p className="footer">{card.userName}</p>
    </div>
  );
};

export default Post;
