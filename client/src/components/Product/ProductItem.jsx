import React from 'react';
import classes from "./styles/ProductItem.module.css";
import BasketButton from "../../UI/Buttons/Product/BasketButton"

function ProductItem(props){
    return(
        <div className={classes.productBlock}>
            <img className={classes.productImage} alt='ProductImg' src={props.ImageLink}/>
            
            <div className={classes.productInfo}>
                <label>Title | Typename</label>
                <label>Price: 31.5$</label>
                <BasketButton/>
            </div>
        </div>
    );
}

export default ProductItem;