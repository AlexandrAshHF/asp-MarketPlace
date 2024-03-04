import React, { useEffect, useState } from "react";
import classes from './styles/Profile.module.css'
import { useNavigate } from "react-router-dom";

function Profile() {
    const [user, setUser] = useState({ id: "", username:"", email: "" });
    const [orders, setOrders] = useState([]);
    const navigate = useNavigate();

    async function fetchProfile(token) {
        let response = await fetch('https://localhost:7004/Account/Profile',
        {
            method: 'GET',
            headers: 
            {
                'Content-Type': 'application/json',
                'Authorization': token,
            }
        });
    
        if(response.ok) {
            let data = await response.json();
            setUser({ id: data.id , username: data.username, email: data.email });
            setOrders(data.orders);
        }
        
        else {
            navigate('Account/Login', {replace: true});
        }
    };

    useEffect(() => {
        let token = localStorage.getItem('Authorization');
        if(token != null)
            fetchProfile(token);
        else
            navigate('Account/Login', {replace: true});
    }, [])

    return(
        <div className={classes.mainBlock}>
            <div>
                <label>{user.username}</label>
                <label>{user.email}</label>
                <div>
                    <button>Logout</button>
                    <button>Change password</button>
                </div>
            </div>
            <div>
                { orders.length < 1 && 
                    <h1>You have no orders</h1>
                }
                {orders.map((item) => 
                (
                    <div key={item.id}>
                        <label>{item.id}</label>
                        <label>{item.total}</label>
                        <label>{item.status}</label>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default Profile;