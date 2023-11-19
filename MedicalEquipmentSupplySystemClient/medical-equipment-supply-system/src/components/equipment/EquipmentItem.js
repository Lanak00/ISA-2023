import classes from './EquipmentItem.module.css';
import Card from '../ui/Card';

function EquipmentItem(props) {

    return(
        <li className={classes.item}>
            <Card>
                <div className={classes.allcont}>
                    <div className={classes.content}>
                        <h2>{props.name}</h2>
                        <h3>Type: {props.type}</h3>
                        <p>Description: {props.description}</p>
                    </div>
                </div>
            </Card>
        </li>
    );

}

export default EquipmentItem;