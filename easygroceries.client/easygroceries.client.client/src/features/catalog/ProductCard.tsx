import { Avatar, Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Product } from "../../app/models/product";
import { BasketItem } from "../../app/models/basket";
import { Link } from 'react-router-dom';
import { useState } from 'react';
import agent from '../../app/api/agent';
import { LoadingButton } from '@mui/lab';
import { useStoreContext } from '../../app/context/StoreContext';
import { currencyFormat } from '../../app/util/util';

interface Props {
    product: Product;
}
interface Props {
    basketitem: BasketItem;
}

export default function ProductCard({ product }: Props) {
    const { setBasket } = useStoreContext();
    const [loading, setLoading] = useState(false);

    function handleAddItem(product:Product) {
        setLoading(true);
        const basketitem: BasketItem = {
            productId: product.id,
            name: product.name,
            price: product.price,
            pictureUrl: product.pictureUrl,
            brand: "",
            type: "",
            quantity: 1
        };
        agent.Basket.addItem(basketitem)
            .then(basket => setBasket(basket))
            .catch(error => console.log(error))
            .finally(() => setLoading(false))
            
    //    agent.Basket.addItem(productId)
    //        .then(basket => setBasket(basket))
    //        .catch(error => console.log(error))
    //        .finally(() => setLoading(false))
    }

    return (
        <Card>
            <CardHeader
                avatar={
                    <Avatar sx={{ bgcolor: 'secondary.main' }}>
                        {product.name.charAt(0).toUpperCase()}
                    </Avatar>
                }
                title={product.name}
                titleTypographyProps={{
                    sx: { fontWeight: 'bold', color: 'primary.main' }
                }}
            />
            <CardMedia
                sx={{ height: 140, backgroundSize: 'contain', bgcolor: 'primary.light' }}
                image={product.pictureUrl}
                title={product.name}
            />
            <CardContent>
                <Typography gutterBottom color='secondary' variant="h5" component="div">
                    {currencyFormat(product.price)}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    {product.brand} / {product.type}
                </Typography>
            </CardContent>
            <CardActions>
                <LoadingButton
                    loading={loading}
                    onClick={() => handleAddItem(product)}
                    size="small">Add to Cart</LoadingButton>
                <Button component={Link} to={`/catalog/${product.id}`} size="small">View</Button>
            </CardActions>
        </Card>
    )
}