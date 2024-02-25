import React from "react";
import classes from "./styles/CommentsBlock.module.css"

function CommentsBlock({comments}, ...params) {
    return(
        <div {...params} className={classes.commentsBlock}>
            <label className={classes.title}>Отзывы</label>
            {comments.map((item, index) => (
                <div key={index} className={classes.comment}>
                    <label className={classes.username}>{item.Username}</label>
                    <label>{"Rating: " + item.Rating + "*"}</label>
                    <p>{item.Text}</p>
                </div>
            ))}
        </div>
    );
}

export default CommentsBlock;