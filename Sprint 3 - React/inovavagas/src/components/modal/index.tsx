import React from 'react';
import { Modal } from 'react-bootstrap';
import ButtonFull from '../../components/button/index';

interface ModalProps {
    tittle: string;
    text: string;
}

const Modals: React.FC<ModalProps> = ({ tittle, text , ...rest}) => {
    return (
        <div>
            <Modal.Dialog>
                <Modal.Header closeButton>
                    <Modal.Title>{tittle}</Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <p>{text}</p>
                </Modal.Body>

            </Modal.Dialog>
        </div>
    )
}

export default Modals;