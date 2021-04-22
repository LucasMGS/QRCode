import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import { Form, Col, Button, Spinner } from 'react-bootstrap';
import './styles.css';
import api from '../../configs/api';
import DateTimePicker from 'react-datetime-picker';


export default function Home() {
	const [file, setFile] = useState([]);
	const [image, setImage] = useState('');
	const [numItem, setNumItem] = useState(0);
	const [grupo, setGrupo] = useState('');
	const [subGrupo, setSubGrupo] = useState('');
	const [centroDeCusto, setCentroDeCusto] = useState('');
	const [itemDesc, setItemDesc] = useState('');
	const [frota, setFrota] = useState('');
	const [localizacao, setLocalizacao] = useState('');
	const [taxaDepreciacao, setTaxaDepreciacao] = useState(0);
	const [vidaUtil, setVidaUtil] = useState('');
	const [notaFiscal, setNotaFiscal] = useState(0);
	const [fornecedor, setFornecedor] = useState('');
	const [dataEntrada, setDataEntrada] = useState(new Date());
	const [dataEntradaString, setDataEntradaString] = useState('');
	const [dataEmissao, setDataEmissao] = useState(new Date());
	const [dataEmissaoString, setDataEmissaoString] = useState('');
	const [valorAquisicao, setValorAquisicao] = useState(0);
	const [ICMS, setICMS] = useState(0);
	const [CIAP, setCIAP] = useState(false);
	const [PIS, setPIS] = useState(0);
	const [COFINS, setCOFINS] = useState(0);
	const [isLoading, setIsLoading] = useState(false);
	var history = useHistory();
	
	
	useEffect(() => {
		localStorage.setItem('logoURL', image);
		return () => false;
	}, [image,dataEntrada,dataEmissao]);

	useEffect(() => {
		var formatEntrada = Intl.DateTimeFormat('pt-br',{
			day: '2-digit',
			month: '2-digit',
			year: 'numeric'
		}).format(dataEntrada);
		setDataEntradaString(formatEntrada)
		var formatEmissao = Intl.DateTimeFormat('pt-br',{
			day: '2-digit',
			month: '2-digit',
			year: 'numeric'
		}).format(dataEmissao);
		setDataEmissaoString(formatEmissao);

	}, [dataEntrada,dataEmissao]);

	async function onSubmit(e,val) {
		console.log(val);
		setIsLoading(true);
		e.preventDefault();
		if(file.isEmpty){
			alert('Insira uma imagem primeiro!');
			return;
		}
		try {
			await uploadLogo();
			var data = {	
				numItem,
				grupo,
				subGrupo,
				centroDeCusto,
				itemDesc,
				frota,
				localizacao,
				taxaDepreciacao,
				vidaUtil,
				notaFiscal,
				fornecedor,
				dataEntrada: dataEntradaString,
				dataEmissao: dataEmissaoString,
				valorAquisicao,
				ICMS,
				CIAP,
				PIS,
				COFINS,
			};
			
			const response = await api.post('Item', data);
			const responseData = response.data;
			console.log(responseData);
			localStorage.setItem('qrCodeUrl', responseData.qrCodeUrl);
			localStorage.setItem('numItem', responseData.numItem);
			history.push('/qrcode');
		} catch (error) {
			alert(`Ocorreu um erro: ${error}`);
		} finally {
			setIsLoading(false);
		}
	}

	async function uploadLogo() {
		const formData = new FormData();
		formData.append('logo', file, file.name);
		const response = await api.post('uploadImage', formData);
		setImage(response.data);
		console.log('image variavel: ', image);
		console.log('resposta do servidor: ', response.data);
	}

	function handleImageChange(e) {
		const file = e.target.files[0];
		setFile(file);
		console.log(file);
	}

	return (
		<div className="application">
			<Form>
				<Form.Group>
					<Form.File id="imagem" onChange={handleImageChange} />
				</Form.Group>
			</Form>
			<Form onSubmit={onSubmit}>
				<Form.Row>
					<Form.Group as={Col} xs={3} controlId="NumItem">
						<Form.Label>Número do item</Form.Label>
						<Form.Control onChange={(e) => setNumItem(+e.target.value)} type="number" placeholder="Numero do item" />
					</Form.Group>
				</Form.Row>

				<Form.Row>
					<Form.Group as={Col} xs={5} controlId="Grupo">
						<Form.Label>Grupo</Form.Label>
						<Form.Control onChange={(e) => setGrupo(e.target.value)} type="input" placeholder="Grupo" />
					</Form.Group>
					<Form.Group as={Col} controlId="SubGrupo">
						<Form.Label>Sub-Grupo</Form.Label>
						<Form.Control onChange={(e) => setSubGrupo(e.target.value)} type="input" placeholder="SubGrupo" />
					</Form.Group>
					<Form.Group as={Col} controlId="CentroDeCusto">
						<Form.Label>Centro de custo</Form.Label>
						<Form.Control onChange={(e) => setCentroDeCusto(e.target.value)} type="input" placeholder="Centro de custo" />
					</Form.Group>
				</Form.Row>

				<Form.Row>
					<Form.Group as={Col} xs={9} controlId="Descricao">
						<Form.Label>Descrição do item</Form.Label>
						<Form.Control onChange={(e) => setItemDesc(e.target.value)} placeholder="Descrição do item" />
					</Form.Group>
					<Form.Group as={Col} controlId="Frota">
						<Form.Label>Frota</Form.Label>
						<Form.Control onChange={(e) => setFrota(e.target.value)} placeholder="Frota" />
					</Form.Group>
				</Form.Row>

				<Form.Group controlId="Localizacao">
					<Form.Label>Localizacao</Form.Label>
					<Form.Control onChange={(e) => setLocalizacao(e.target.value)} />
				</Form.Group>

				<Form.Group controlId="Taxa de apreciação">
					<Form.Label>Taxa de apreciação</Form.Label>
					<Form.Control onChange={(e) => setTaxaDepreciacao(+e.target.value)} type="number" />
				</Form.Group>

				<Form.Group controlId="VidaUtil">
					<Form.Label>Vida útil estimada</Form.Label>
					<Form.Control onChange={(e) => setVidaUtil(+e.target.value)} type="number" />
				</Form.Group>

				<Form.Row>
					<Form.Group as={Col} controlId="NotaFiscal">
						<Form.Label>Nota fiscal estimada</Form.Label>
						<Form.Control onChange={(e) => setNotaFiscal(+e.target.value)} type="number" placeholder="Nota fiscal estimada" />
					</Form.Group>
					<Form.Group as={Col} controlId="Fornecedor">
						<Form.Label>Fornecedor</Form.Label>
						<Form.Control onChange={(e) => setFornecedor(e.target.value)} placeholder="Fornecedor" />
					</Form.Group>
				</Form.Row>

				<Form.Row>
					<Form.Group as={Col} controlId="DataEntrada">
						<Form.Label>Data de entrada</Form.Label>
						<DateTimePicker className="ml-2" onChange={setDataEntrada} value={dataEntrada}/>

					</Form.Group>
					<Form.Group as={Col} controlId="DataEmissao">
						<Form.Label>Data Emissao</Form.Label>
						<DateTimePicker className="ml-2" onChange={setDataEmissao} value={dataEmissao}/>
					</Form.Group>
					</Form.Row>
				

				<Form.Group controlId="ValorAquisicao">
					<Form.Label>Valor de aquisição</Form.Label>
					<Form.Control onChange={(e) => setValorAquisicao(+e.target.value)} type="number"  />
				</Form.Group>

				<Form.Row>
					<Col>
						<Form.Group controlId="ICMS">
							<Form.Label>ICMS</Form.Label>
							<Form.Control onChange={(e) => setICMS(+e.target.value)} type="number" placeholder="ICMS" />
						</Form.Group>
					</Col>
				</Form.Row>

				<Form.Group controlId="CIAP">
					<Form.Check onChange={(e) => setCIAP(e.target.checked)} type="checkbox" label="CIAP" />
				</Form.Group>

				<Form.Group controlId="PIS">
					<Form.Label>PIS</Form.Label>
					<Form.Control onChange={(e) => setPIS(+e.target.value)} type="number" placeholder="PIS" />
				</Form.Group>

				<Form.Group controlId="COFINS">
					<Form.Label>COFINS</Form.Label>
					<Form.Control onChange={(e) => setCOFINS(+e.target.value)} type="number" placeholder="COFINS" />
				</Form.Group>
				<div>
					<Button variant="dark" type="submit" disabled={isLoading}>
						<Spinner style={{ height: 20, width: 20 }} hidden={!isLoading} className="mr-2" animation="grow" variant="light" />
						{isLoading ? 'Criando QRCode' : 'Criar QRCode'}
					</Button>
				</div>
			</Form>
		</div>
	);
}
