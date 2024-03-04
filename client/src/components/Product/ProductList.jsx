import React, { useEffect, useState } from 'react';
import ProductItem from './ProductItem'
import classes from './styles/ProductList.module.css'

function ProductList({isCatalog = true}){
    var basketKey = 'BasketKey';

    const [basketItems, ChangeBasket] = useState(localStorage.getItem(basketKey) != null 
    ? localStorage.getItem(basketKey).split(',')
    : []);

    const [list, setList] = useState([]);
    const [clickedItems, setClickedItems] = useState([]);

    async function fecthProducts() {
        var response = await fetch('https://localhost:7004/Product/ProductsList', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        });

        if(response.ok){
            let data = await response.json();
            console.log(data);
            setList(data);
        }
    }

    async function fetchBasket() {
        if(localStorage.getItem(basketKey) == null)
            return;

        let IDs = localStorage.getItem(basketKey).split(',');

        if(IDs[0] == "")
            IDs.shift();
        console.log(IDs);
        console.log(JSON.stringify(IDs));
        var response = await fetch('https://localhost:7004/Product/ProductsRangeById', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(IDs)
        });

        if(response.ok){
            let data = await response.json();
            console.log(data);
            setList(data);
        }
    }

    useEffect(() => {
        if(isCatalog)
            fecthProducts();

        else {
            fetchBasket();
        }
    }, []);

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
        <div className={classes.productList}>
            {list.map((product) => (
                <ProductItem item={product} basketClick={EntryItem}
                 key={product.id} clicked={clickedItems.includes(product.Id)}/>
            ))}
        </div>
    );
}

export default ProductList;