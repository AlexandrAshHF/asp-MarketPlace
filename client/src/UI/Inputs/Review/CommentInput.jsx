import React, { useEffect, useRef } from "react";
import classes from './CommentInput.module.css'

const CommentInput = ({props}) => {
    const area = useRef();

    useEffect(() =>{
        area.current.style.height = 'auto';
        area.current.style.height = `${area.current.scrollHeight}px`;
    }, [props.value])

    return(
        <textarea ref={area} {...props} className={classes.comment} id={'commentArea'}></textarea>
    );
}

export default CommentInput;