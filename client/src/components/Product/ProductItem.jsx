import React from 'react';
import classes from "./styles/ProductItem.module.css";
import BasketButton from "../../UI/Buttons/Product/BasketButton"

function ProductItem({item, basketClick, clicked, ...props}){
    const buttonStyle = clicked
     ? {backgroundColor: 'rgba(128, 0, 0, 0.2)'}
     : {backgroundColor:'rgba(0, 128, 0, 0.1)'};

    return(
        <div className={classes.productBlock} {...props}>
            <img className={classes.productImage} alt='ProductImg' src={item.ImageLink}/>
            
            <div className={classes.productInfo}>
                <label>{item.Title}</label>
                <label>{item.TypeName}</label>
                <label>Price: {item.Price}</label>
            </div>
            <BasketButton onClick={() => basketClick(item.Id)} style={buttonStyle}/>
        </div>
    );
}

export default ProductItem;