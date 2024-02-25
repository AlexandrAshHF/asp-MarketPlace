import React from "react";
import classes from "./styles/SelectedProduct.module.css"
import ImageModule from "./Modules/ImageModule";
import DescriptionBlock from "./Modules/DescriptionBlock";
import CommentsBlock from "./Modules/CommentsBlock"

function SelectedProduct(params) {
    return(
        <div className={classes.productBlock}>
            <div className={classes.infoBlock}>
                <ImageModule/>
                <DescriptionBlock SellerName={"SellerName"} Title={"Title"}
                TypeName={"TypeName"} Description={"DescriptionDescriptionDescriptionDescriptionDescriptionDescription" +
                "DescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescription"
                +"DescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescription"}/>
            </div>
            <CommentsBlock comments = {[{Username:"name1", Rating:4, Text:"Comment text1"}, 
            {Username:"name2", Rating:2, Text:"Comment text2"}]}/>
        </div>
    );
}

export default SelectedProduct;