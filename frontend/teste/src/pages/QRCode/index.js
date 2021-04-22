import React from 'react';
import './styles.css';
import { Button } from 'react-bootstrap';

function QRCode() {
	const qrCodeUrl = localStorage.getItem('qrCodeUrl');
	const numItem = localStorage.getItem('numItem');
	const logoURL = localStorage.getItem('logoURL');
	return (
		<>
			<div className="container" style={{ width: 'fit-content' }} hidden={!logoURL && !qrCodeUrl}>
				<img height={350} width={350} alt="QRCode" src={qrCodeUrl} />
				<div className="content-container">
					<div className="container-logo">
						<img className="logo-img" height={200} width={300} alt="Logo Img" src={logoURL} />
					</div>
					<div className="qrNumber">{numItem}</div>
				</div>
			</div>
			<div className="print-button naoImprimir">
				<Button onClick={window.print}>Imprimir</Button>
			</div>
		</>
	);
}

export default QRCode;
