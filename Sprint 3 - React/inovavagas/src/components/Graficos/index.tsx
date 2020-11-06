import React from 'react';
import { Container, Row } from 'react-bootstrap';
import {Line, Pie} from 'react-chartjs-2';

const data = {
    labels: [
        'Jan',
        'Currículos Recebidos',
        'Contratos Efetivados',
        'Mensagem Enviadas',
        'qualquer coisa'
],
colors:[
'#C5483E',
'#79CC76',
'#005086',
'#CE82CE'
],
datasets: [{
    data: [300, 50, 100, 90, 50],
    backgroundColor:[
    '#005086',
    '#005086'
    ]
    }]
};

function Grafico(){
    return(
<Container>
    <Row>
            <Line data={data}/>
        <div className="style">
            <Pie data={data}/>
            <Pie width={300} height={300} data={data}/>
        </div>
    </Row>
</Container>
    )

}
export default Grafico;