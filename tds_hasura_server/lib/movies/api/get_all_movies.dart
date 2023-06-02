import 'dart:convert';

import 'package:hasura_connect/hasura_connect.dart' hide Request, Response;
import 'package:shelf/shelf.dart';
import 'package:shelf_modular/shelf_modular.dart';

Future<Response> getAllMovies(
  Request request,
  Injector injector,
  ModularArguments arguments,
) async {
  final hasuraConnect = injector.get<HasuraConnect>();

  var hasuraResponse = await hasuraConnect.query('''
      query getAllMovies {
        movies {
          movieID
          name
          movies_category {
            categoryID
            name
          }
        }
      }
      ''');

  return Response.ok(
    jsonEncode(hasuraResponse['data']),
    headers: {'Content-Type': 'application/json'},
  );
}
