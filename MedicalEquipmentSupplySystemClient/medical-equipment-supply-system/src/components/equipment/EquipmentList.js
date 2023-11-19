import EquipmentItem from "./EquipmentItem";
import classes from './EquipmentList.module.css';

function EquipmentList(props) {
    return (
        <ul className={classes.list}>
            {props.equipment.map(equip=> <EquipmentItem
                key = {equip.id}
                id = {equip.id}
                name = {equip.name}
                type = {equip.type}
                description = {equip.description}
            />)}
        </ul>
    )
}

export default EquipmentList;