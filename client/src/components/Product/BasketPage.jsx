import React from "react";
import classes from './styles/BasketPage.module.css'
import ProductList from './ProductList'

function BasketPage() {


    return(
        <div className={classes.mainBlock}>
            <form className={classes.formOrder}>

            </form>
            <ProductList products={null}/>
        </div>
    );
}

export default BasketPage;