import BasketSummary from '../basket/BasketSummary';
import BasketTable from '../basket/BasketTable';
import { Typography, Grid } from '@mui/material';
import { useStoreContext } from '../../app/context/StoreContext';
import { useState, useEffect } from 'react';

export default function Review() {
    const [loading, setLoading] = useState(true);
    const { basket } = useStoreContext();
    const [status, setStatus] = useState({
        loading: false,
        name: ''
    });
  return (
    <>
      <Typography variant="h6" gutterBottom>
        Order summary
      </Typography>
      {basket &&
        <BasketTable items={basket.items} isBasket={false} />}
      <Grid container>
        <Grid item xs={6} />
        <Grid item xs={6}>
          <BasketSummary />
        </Grid>
      </Grid>
    </>
  );
}