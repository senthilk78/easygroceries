import { Typography } from '@mui/material';
import agent from '../../app/api/agent';
import { useState, useEffect } from 'react';
import LoadingComponent from '../../app/layout/LoadingComponent';
import { Basket } from '../../app/models/basket';


export default function ContactPage() {
    const [loading, setLoading] = useState(true);
    const [basket, setBasket] = useState<Basket | null>(null);

    useEffect(() => {
        agent.Basket.get()
            .then(data => {
                setBasket(data.shoppingCart)
            })
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }, [])

    if (loading) return <LoadingComponent message='Loading products...' />

    return (
        <>
            <h1>{basket?.id}</h1>
        </>
    )
}