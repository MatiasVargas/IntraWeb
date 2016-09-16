<?php

/**
 * Representa el data de los gastos
 * almacenados en la base de datos
 */
require 'DatabaseConnection.php';

class Gastos
{
    // Nombre de la tabla asociada a esta clase
    const TABLE_NAME = "alumno";

    const RUT = "rut";

    const NOMBRE = "nombre";

    const CONTRASEÑA = "contraseña";

    const CORREO = "correo";

    function __construct()
    {
    }

    /**
     * Obtiene todos los gastos de la base de datos
     * @return array|bool Arreglo con todos los gastos o false en caso de error
     */
    public static function getAll()
    {
        $consulta = "SELECT * FROM " . self::TABLE_NAME;
        try {
            // Preparar sentencia
            $comando = DatabaseConnection::getInstance()->getDb()->prepare($consulta);
            // Ejecutar sentencia preparada
            $comando->execute();

            return $comando->fetchAll(PDO::FETCH_ASSOC);

        } catch (PDOException $e) {
            return false;
        }
    }

    public static function insertRow($object)
    {
        try {

            $pdo = DatabaseConnection::getInstance()->getDb();

            // Sentencia INSERT
            $comando = "INSERT INTO " . self::TABLE_NAME . " ( " .
                self::RUT . "," .
                self::NOMBRE . "," .
                self::CONTRASEÑA . "," .
                self::CORREO . ")" .
                " VALUES(?,?,?,?)";

            // Preparar la sentencia
            $sentencia = $pdo->prepare($comando);

            $sentencia->bindParam(1, $rut);
            $sentencia->bindParam(2, $nombre);
            $sentencia->bindParam(3, $contraseña);
            $sentencia->bindParam(4, $correo);

            $monto = $object[self::RUT];
            $etiqueta = $object[self::NOMBRE];
            $fecha = $object[self::CONTRASEÑA];
            $descripcion = $object[self::CORREO];

            $sentencia->execute();

            // Retornar en el último id insertado
            return $pdo->lastInsertId();
        } catch (PDOException $e) {
            return false;
        }

    }
}

?>