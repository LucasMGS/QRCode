import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import Home from './pages/Home/index';
import QRCode from './pages/QRCode/index';

export default function Routes() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Home} />
                <Route path="/qrcode" component={QRCode} />                
            </Switch>
        </BrowserRouter>
    );
}