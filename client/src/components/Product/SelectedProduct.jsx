import React, { useState } from "react";
import classes from "./styles/SelectedProduct.module.css"
import ImageModule from "./Modules/ImageModule";
import DescriptionBlock from "./Modules/DescriptionBlock";
import CommentsBlock from "./Modules/CommentsBlock";
import CommentInput from '../../UI/Inputs/CommentInput';

function SelectedProduct() {
    const [comment, setComment] = useState("");
    const [product, setProduct] = useState(null);

    return(
        <div className={classes.productBlock}>
            <div className={classes.infoBlock}>
                <ImageModule/>
                <DescriptionBlock SellerName={product.SellerName} Title={product.Title}
                TypeName={product.TypeName} Description={product.Description}/>
            </div>
            <div className={classes.commentInput}>
                <label>Your comment:</label>
                <CommentInput placeholder='Your comment' onChange={e => { setComment(e.target.value) }} value={comment}/>
            </div>
            <CommentsBlock comments = {[{Username:"name1", Rating:4, Text:"Comment text1"}, 
            {Username:"name2", Rating:2, Text:"Comment text2"}]}/>
        </div>
    );
}

export default SelectedProduct;