import React from 'react';
import classes from "./ProductItem.module.css"

function ProductItem(props){
    return(
        <div className={classes.productBlock}>
            <img className={classes.productImage} alt='ProductImg' src={props.ImageLink}/>
            
            <div className={classes.productInfo}>
                <label>Title | Typename</label>
                <label>Price: 31.5$</label>
                <button className={classes.productButton}>
                    
                </button>
            </div>
        </div>
    );
}

export default ProductItem;