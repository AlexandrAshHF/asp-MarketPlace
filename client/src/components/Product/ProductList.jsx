import React, { useState } from 'react';
import ProductItem from './ProductItem'
import classes from './styles/ProductList.module.css'

function ProductList({list}, ...params){
    var basketKey = 'BasketKey';

    const [basketItems, ChangeBasket] = useState(localStorage.getItem(basketKey) != null 
    ? localStorage.getItem(basketKey).split(',')
    : []);

    const [clickedItems, setClickedItems] = useState([]);

    function EntryItem(id) {
        console.log(id);
        let newBasket;
        if(basketItems.find((x) => x === id))
            newBasket = basketItems.filter(x => x !== id);
        else
            newBasket = [...basketItems, id];

        ChangeBasket(newBasket);
        localStorage.setItem(basketKey, newBasket);

        if (clickedItems.includes(id)) {
            setClickedItems(clickedItems.filter(itemId => itemId !== id));
        } else {
            setClickedItems([...clickedItems, id]);
        }
    }

    return(
        <div {...params} className={classes.productList}>
            {list.map((product) => (
                <ProductItem item={product} basketClick={EntryItem}
                 key={product.Id} clicked={clickedItems.includes(product.Id)}/>
            ))}
        </div>
    );
}

export default ProductList;