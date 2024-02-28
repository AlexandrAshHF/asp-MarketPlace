import React from 'react';
import classes from "./styles/ProductItem.module.css";
import BasketButton from "../../UI/Buttons/Product/BasketButton"

function ProductItem({item, basketClick, clicked, ...props}){
    const buttonStyle = clicked
     ? {backgroundColor: 'rgba(128, 0, 0, 0.2)'}
     : {backgroundColor:'rgba(0, 128, 0, 0.1)'};

     const iconButton = clicked 
     ? '/images/redBasket.png'
     : '/images/greenBasket.png';

    return(
        <div className={classes.productBlock} {...props}>
            <img className={classes.productImage} alt='ProductImg' src={item.ImageLink}/>
            
            <div className={classes.productInfo}>
                <label>{item.title}</label>
                <label>{item.typeName}</label>
                <label>Price: {item.price}</label>
            </div>
            <BasketButton imgLink={iconButton} onClick={() => basketClick(item.id)} style={buttonStyle}/>
        </div>
    );
}

export default ProductItem;