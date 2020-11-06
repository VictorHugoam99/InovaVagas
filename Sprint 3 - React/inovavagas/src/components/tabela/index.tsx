import React from 'react';
import {Table} from 'react-bootstrap';
import './style.css'; 

function Tabela() {
    return (
        <div className="all">
                <div className="titulo">
                    <h1>Gerenciar Usuarios</h1>
                </div>
                <div className="pesquisa">
                    <input type="text" id="txtBusca" placeholder="Buscar..."/>
                    <button id="btnBusca">Buscar</button>
                </div>
            <Table striped bordered hover size="sm">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Username</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>Jacob</td>
                        <td>Thornton</td>
                        <td>@fat</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Larry the Bird</td>
                        <td>@twitter</td>
                    </tr>
                </tbody>
            </Table>
        </div>
    );
}

export default Tabela;