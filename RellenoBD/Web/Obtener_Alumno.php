<?php
/**
 * Obtiene todos los gastos de la base de datos
 */

/**
 * Constantes para construcción de respuesta
 */
const ESTADO = "estado";
const DATOS = "alumno";
const MENSAJE = "mensaje";

const CODIGO_EXITO = 1;
const CODIGO_FALLO = 2;

require '../data/Gastos.php';


if ($_SERVER['REQUEST_METHOD'] == 'GET') {

    // Obtener gastos de la base de datos
    $gastos = Gastos::getAll();

    // Definir tipo de la respuesta
    header('Content-Type: application/json');

    if ($gastos) {
        $datos[ESTADO] = CODIGO_EXITO;
        $datos[DATOS] = $alumno;
        print json_encode($datos);
    } else {
        print json_encode(array(
            ESTADO => CODIGO_FALLO,
            MENSAJE => "Ha ocurrido un error"
        ));
    }
}