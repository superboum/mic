FROM fedora:latest
LABEL maintainer "quentin@dufour.io"

RUN echo "fastestmirror=1" >> /etc/dnf/dnf.conf \
    && dnf install -y monodevelop zip nuget ca-certificates

RUN cert-sync /etc/pki/tls/certs/ca-bundle.crt
