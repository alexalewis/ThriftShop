docker build -t thrift-shop-image .

docker tag thrift-shop-image registry.heroku.com/my-thrift-shop/web

docker push registry.heroku.com/my-thrift-shop/web

heroku container:release web -a my-thrift-shop