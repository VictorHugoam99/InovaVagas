import React, { useState } from 'react';
// import './style.css';
// import { Card } from 'react-bootstrap';
// import inova from '../../assets/images/inovaVermelho.png';
// import editar from '../../assets/images/canetinha_Cinza.png';
// import apagar from '../../assets/images/lixo_Cinza.png';
// import mais from '../../assets/images/mais_Cinza.png'
// import { Link, useHistory } from 'react-router-dom';
// import ButtonFull from '../../components/button/index';
// import {Modal} from 'react-bootstrap';
// import Button from 'react-bootstrap';

// interface CardVagaProps {
//     tittle: string;
//     text: string;
// }

// const CardVaga: React.FC<CardVagaProps> = ({ tittle, text, ...rest }) => {

//     const history = useHistory();

//     const [idVaga, setIdVaga] = useState(0);
//     const [vaga, setVaga] = useState('');
//     const [vagas, setVagas] = useState([]);

//     const [show, setShow] = useState(false);

//     const handleClose = () => setShow(false);
//     const handleShow = () => setShow(true);

//     const apagarVaga = (id: number) => {
//         fetch('http://localhost:5000/api/Vaga/' + id, {
//             method: 'DELETE', 
//             headers: {
//                 authorization: 'Bearer' + localStorage.getItem('token-inova')
//             }
//         })
//         .then(resp => resp.json())
//         .catch(e => console.error(e));
//     }


//     const visualizarVagaEditar = (id : number) => {

//         fetch('http://localhost:5000/api/Vaga/' + id, {
//             method: 'GET',
//             headers: {
//                 authorization: 'Bearer ' + localStorage.getItem('token-inova')
//             }
//         })
//             .then( resp => resp.json())
//             .then( dados => {
//                 setIdVaga(dados.idVaga);
//                 console.log(id);
//                 // localStorage.setItem( 'IdVaga', String(idVaga))
//                 history.push(`/editarVaga?id=${id}`)
//             })
//             .catch(err => console.error(err));
//     }

//     return (
//         <div className="cardVaga">
//             <Card bsPrefix="main-card">
//                 <Card.Body bsPrefix="card-body">
//                     <div className="cardText-container">
//                         <Card.Title bsPrefix="card-tittle">{tittle}</Card.Title>
//                         <Card.Text bsPrefix="card-info">
//                             <ul>
//                                 <li>Tipo de vaga</li>
//                             </ul>
//                         </Card.Text>
//                         <div className="content-container">
//                             <Card.Text bsPrefix="card-text1">Descrição da vaga:</Card.Text>
//                             <Card.Text bsPrefix="card-text">{text}</Card.Text>
//                         </div>
//                     </div>
//                     <div className="imagens">
//                         <div className="imgEmpresa-container">
//                             <Card.Img src={inova} bsPrefix="imgEmpresa" ></Card.Img>
//                         </div>
//                         <div className="atalhos">
//                             <button onClick={() => visualizarVagaEditar(idVaga)}>
//                                 <img src={editar} />
//                             </button>
//                             <button onClick={handleShow}>
//                                 <img src={apagar} />
//                             </button>
//                         </div>
//                         <Modal show={show} onHide={handleClose}>
//                             <Modal.Header closeButton>
//                                 <Modal.Title>Atenção!</Modal.Title>
//                             </Modal.Header>
//                             <Modal.Body>Deseja apagar essa vaga?</Modal.Body>
//                             <Modal.Footer>
//                                 <ButtonFull name="Sim" onClick={() => apagarVaga(idVaga)}/>
//                                 <ButtonFull name="Não" onClick={handleClose}/>
//                             </Modal.Footer>
//                         </Modal>
//                     </div>

//                 </Card.Body>
//             </Card>
//         </div>
//     )
// }

// export default CardVaga;