import React from 'react';
import './styles.css';
// import { Image, Container, Row, Col } from 'react-bootstrap';

function QRCode() {
	const qrCodeUrl = localStorage.getItem('qrCodeUrl');
	const numItem = localStorage.getItem('numItem');
	const logoURL = localStorage.getItem('logoURL');

	return (
		<>
			<div className="container" style={{width: "40%"}} hidden={!logoURL && !qrCodeUrl} >
				<img height={350} width={350} alt="QRCode" src={qrCodeUrl} />
				<div className="content-container">
					<div className="container-logo">
						<img className="logo-img" height={200} width={300} alt="Logo Img" src={logoURL} />
					</div>
					<div className="qrNumber">{numItem}</div>
				</div>
			</div>
			{/* <Container>
				<Row>
					<Col md={2} xs={3}>
						<Image src={qrCodeURL} thumbnail />
					</Col>
					<Col xs={4} md={2}>
						<Image height={150} width={300} src={logoURL} rounded />
					</Col>
				</Row>
			</Container> */}
		</>
	);
}

export default QRCode;
