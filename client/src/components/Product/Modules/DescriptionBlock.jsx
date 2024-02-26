import React from "react";
import classes from './styles/DescriptionBlock.module.css'

function DescriptionBlock({params}) {
    return(
        <div className={classes.descBlock}>
            <label className={classes.sellerName}>{params.SellerName}</label>
            <div className={classes.titleBlock}>
                <label className={classes.title}>{params.Title}</label>
                {" \u00A0|\u00A0 "}
                <label>{params.TypeName}</label>
            </div>
            <p>{params.Description}</p>
        </div>
    );
}

export default DescriptionBlock;